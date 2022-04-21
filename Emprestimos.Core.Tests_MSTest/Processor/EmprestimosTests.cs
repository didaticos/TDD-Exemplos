using Emprestimos.Core.Domain;
using Emprestimos.Core.Processor;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Emprestimos.Core.Tests_MSTest.Processor
{

    [TestClass]
    public class EmprestimosTests
    {
        EmprestimoProcessor _processor;

        [TestInitialize]
        public void Inicializar()
        {
            _processor = new EmprestimoProcessor();
        }

        [TestMethod]
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

        [TestMethod]
        public void DeveRetornarUmaExceptionSeReqForNula()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => _processor.LerDados(null));
            Assert.AreEqual("req", exception.ParamName);
        }
    }
}
