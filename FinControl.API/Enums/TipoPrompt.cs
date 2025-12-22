namespace FinControl.API.Enums
{
    public enum TipoPrompt
    {
        AnaliseGastos = 1,
        ResumoMensal = 2,
        DicasEconomia = 3,
        PrevisaoGastos = 4,
        ComparacaoPeriodos = 5,
        AnaliseCategoria = 6,
        PlanejamentoMeta = 7,

        AdicionarTransacao = 10,
        AdicionarReceita = 11,
        AdicionarDespesa = 12,
        RegistrarPix = 13,
        RegistrarTransferencia = 14,

        CadastrarCategoria = 20,
        CadastrarConta = 21,
        CadastrarCartao = 22,
        CadastrarMeta = 23,
        CadastrarOrcamento = 24,

        RegistrarParcelamento = 30,
        RegistrarRecorrente = 31,

        ConsultarSaldo = 40,
        ConsultarFatura = 41,
        ConsultarExtrato = 42,
        ConsultarMetas = 43,

        Personalizado = 99
    }
}
