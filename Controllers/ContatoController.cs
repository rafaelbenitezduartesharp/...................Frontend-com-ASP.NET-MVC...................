using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{

    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var ContatoBanco = _context.contatos.Find(contato.Id);

            ContatoBanco.Nome = contato.Nome;
            ContatoBanco.Telefone = contato.Telefone;
            ContatoBanco.Ativo = contato.Ativo;

            _context.contatos.Update(ContatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);

        }

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBanco = _context.contatos.Find(contato.Id);

            _context.contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}