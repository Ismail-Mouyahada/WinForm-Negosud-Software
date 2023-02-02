using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class UtilisateurAuth
    {
        public string? Email { get; set; }
        public string? MotDePasse { get; set; }

        public UtilisateurAuth(string? email, string? motDePasse)
        {
            Email = email;
            MotDePasse = motDePasse;
        }
    }
}
