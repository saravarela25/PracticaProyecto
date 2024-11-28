using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contraseña { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contraseña = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                // Haciendo debug aqui verifica, puse mensaje para control de errores      - Alejo
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contraseña))
                {
                    ViewData["Error"] = "Debe ingresar ambos campos.";
                    return;
                }

                if (Email == "Usuario" && Contraseña == "123")
                {
                    HttpContext.Session.SetString("Usuario", Email!);
                    EstaLogueado = true;
                    ViewData["Logged"] = true;
                }
                else
                {
                    ViewData["Error"] = "Credenciales incorrectas.";
                    OnPostBtClean();
                }
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}