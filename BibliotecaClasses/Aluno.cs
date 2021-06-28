namespace BibliotecaClasses
{
    public class Aluno
    {
        #region Propriedades

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Morada { get; set; }

        public string Telemovel { get; set; }

        public string Email { get; set; }

        public Data DataNascimento { get; set; }

        public override string ToString()
        {
            return $"{Id} {Nome}";
        }

        #endregion        
    }
}
