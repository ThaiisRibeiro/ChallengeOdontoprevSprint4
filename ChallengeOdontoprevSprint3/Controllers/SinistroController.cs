using ChallengeOdontoprevSprint3.DTO;
using ChallengeOdontoprevSprint3.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ChallengeOdontoprevSprint3.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class SinistroController : ControllerBase
    {
        private readonly MLContext mlContext;
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "ML", "modelo_sinistro.zip");
        private readonly string caminhoCsv = Path.Combine(Environment.CurrentDirectory, "ML", "DadosTreinamento.csv");

        public SinistroController()
        {
            mlContext = new MLContext();
        }

        [HttpGet("treinar")]
        public IActionResult TreinarModelo()
        {
            if (!System.IO.File.Exists(caminhoCsv))
                return BadRequest($"❌ Arquivo de treinamento não encontrado em: {caminhoCsv}");

            // Carrega dados do CSV
            var dados = mlContext.Data.LoadFromTextFile<DadosAgendamentoML>(
                path: caminhoCsv,
                hasHeader: true,
                separatorChar: ',');

            // Cria pipeline: converte IsSinistro para Label e concatena features
            var pipeline = mlContext.Transforms.CopyColumns(
                    outputColumnName: "Label",
                    inputColumnName: nameof(DadosAgendamentoML.IsSinistro))
                .Append(mlContext.Transforms.Concatenate(
                    "Features",
                    nameof(DadosAgendamentoML.QtdAgendamentosPaciente),
                    nameof(DadosAgendamentoML.QtdAgendamentosDentista)))
                .Append(mlContext.BinaryClassification.Trainers.FastTree());

            // Treina o modelo
            var modeloTreinado = pipeline.Fit(dados);

            // Salva o modelo treinado
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
                Directory.CreateDirectory(pastaModelo!);

            mlContext.Model.Save(modeloTreinado, dados.Schema, caminhoModelo);

            return Ok("✅ Modelo treinado e salvo com sucesso!");
        }

        [HttpPost("verificar")]
        public IActionResult VerificarSinistro([FromBody] VerificacaoSinistroDTO entrada)
        {
            if (!System.IO.File.Exists(caminhoModelo))
                return BadRequest("❌ O modelo ainda não foi treinado! Acesse /api/sinistro/treinar primeiro.");

            // Carrega o modelo salvo
            var model = mlContext.Model.Load(caminhoModelo, out _);

            // Cria o motor de predição
            var engine = mlContext.Model.CreatePredictionEngine<DadosAgendamentoML, ResultadoInterno>(model);

            // Cria entrada para ML (IsSinistro não é usado na predição, só precisa existir)
            var entradaML = new DadosAgendamentoML
            {
                QtdAgendamentosPaciente = entrada.QtdAgendamentosPaciente,
                QtdAgendamentosDentista = entrada.QtdAgendamentosDentista,
                IsSinistro = false
            };

            var resultado = engine.Predict(entradaML);

            return Ok(new ResultadoSinistro
            {
                PossivelSinistro = resultado.PredictedLabel,
                Probabilidade = resultado.Probability
            });
        }

        private class ResultadoInterno
        {
            [ColumnName("PredictedLabel")]
            public bool PredictedLabel { get; set; }

            public float Probability { get; set; }
        }
    }
}

