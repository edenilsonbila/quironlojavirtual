namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "smtp.quiron.com.br";
        public int ServidorPorta = 587;
        public string Usuario = "quiron";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"c:\enviaemail";
        public string De = "edenilsonbila@yahoo.com";
        public string Para = "edenilsonbila@yahoo.com";
    }
}