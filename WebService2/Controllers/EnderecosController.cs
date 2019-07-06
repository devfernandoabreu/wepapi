using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService2.Models;

namespace WebService2.Controllers
{
    [Route("api")]
    public class EnderecosController : ControllerBase
    {
        private readonly Context _context;

        public EnderecosController(Context context)
        {
            _context = context;
        }

        [HttpGet("Endereco/Enderecos")]
        public IEnumerable<ConsultaCep> GetAll()
        {
            List<ConsultaCep> enderecos = _context.ConsultaCep.ToList();
            return enderecos;
        }

        [HttpGet("Endereco/Enderecos/{cep}")]
        public IEnumerable<ConsultaCep> GetPorCep(string cep)
        {
            var endereco = _context.ConsultaCep.Where(s => s.Cep == cep);
            return endereco;
        }

        [HttpGet("Endereco/EnderecosPorEstado/{uf}")]
        public IEnumerable<ConsultaCep> GetPorEstado(string uf)
        {
            List<ConsultaCep> enderecos = _context.ConsultaCep.Where(s => s.Uf == uf).ToList();
            return enderecos;
        }
    }
}