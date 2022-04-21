using Emprestimos.Core.Domain;
using Emprestimos.Core.Processor;

using NUnit.Framework;

using System;

namespace Emprestimos.Core.Tests_nUnit.Processor
{
    public class EmprestimosTests
    {
        EmprestimoProcessor _processor;

        [SetUp]
        public void Setup()
        {
            _processor = new EmprestimoProcessor();
        }

        [Test]
        public void DeveRetornarDadosEmprestimosComValoresDaRequisicao()
        {
            //organizar requisição
            var req = new EmprestimoReq()
            {
                PrimeiroNome = "Diogo",
                UltimoNome = "Santos",
                Email = "diogo@diogo.com",
                Data = DateTime.Now
            };

            //processar a requisição e retornar o resultado
            EmprestimoResult result = _processor.LerDados(req);

            //Afirmação
            Assert.IsNotNull(result);
            Assert.AreEqual(req.PrimeiroNome, result.PrimeiroNome);
            Assert.AreEqual(req.UltimoNome, result.UltimoNome);
            Assert.AreEqual(req.Email, result.Email);
            Assert.AreEqual(req.Data, result.Data);
        }

        [Test]
        public void DeveRetornarUmaExceptionSeReqForNula()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.LerDados(null));
            Assert.AreEqual("req", exception.ParamName);
        }
    }
}
