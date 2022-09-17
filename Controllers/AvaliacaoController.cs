using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
 
using Microsoft.AspNetCore.Mvc;
using pifinal.Models;

namespace pifinal.Controllers;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {

        [HttpGet]
        public List<Avaliacao> Listar()
        {
            List<Avaliacao> Avaliacaos = new List<Avaliacao>();
 
            Avaliacao av1 = new Avaliacao
            {
                data = "10/05/2022",
                disciplina = new Disciplina { nome="PI IV"},
                avaliacao = 5,
                observacao = "Excelente Aula"
            };
 
            Avaliacaos.Add(av1);
 
            Avaliacao av2 = new Avaliacao
            {
                data = "15/05/2022",
                disciplina =new Disciplina { nome="SO II"} ,
                avaliacao = 5,
                observacao = "Aula bem teorica"
            };
 
            Avaliacaos.Add(av2);
 
            Avaliacao av3 = new Avaliacao
            {
                data = "20/05/2022",
                disciplina = new Disciplina { nome="BD III"},
                avaliacao = 3,
                observacao = "Aula bem pratica"
            };
 
            Avaliacaos.Add(av3);

            return Avaliacaos;
            
        }

        [HttpPost]
        public List<Avaliacao> Cadastrar([FromForm]Avaliacao novoAvaliacao)
        {
            List<Avaliacao> Avaliacaos = new List<Avaliacao>();

            Avaliacao av1 = new Avaliacao
            {
                data = novoAvaliacao.data,
                disciplina = new Disciplina { nome="PI IV", id=novoAvaliacao.disciplina_id},
                avaliacao = novoAvaliacao.avaliacao,
                observacao = novoAvaliacao.observacao
            };
 
            Avaliacaos.Add(av1);
           return Avaliacaos;
        }
 
        [HttpPut]
        public string Alterar([FromForm]Avaliacao Avaliacaos)
        {
            return "Avaliacao(a) alterado(a) com sucesso!";
        }

        [HttpGet]
        public Avaliacao Consultar(int idAvaliacao)
        {
            return new Avaliacao 
            { 
                data = "27/05/2022",
                disciplina = new Disciplina { nome="BD III"},
                avaliacao = 3,
                observacao = "Excelente Aula"
            };
        }

        [HttpDelete("{idAvaliacao}")]
        public string Excluir(int idAvaliacao)
        {
            return "Avaliacao(a) excluído(a) com sucesso!";
        }

 
    }
