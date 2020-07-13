using DB_SERVER.Infra.Data.Interfaces;

namespace DB_SERVER.Aplicacao.Aplicacoes
{
    public abstract class BaseApp
    {
        private readonly ITransacao _trans;

        protected BaseApp(ITransacao trans)
        {
            _trans = trans;
        }

        public void Commit()
        {
            _trans.Commit();
        }
    }
}