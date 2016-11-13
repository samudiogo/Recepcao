﻿using DPGERJ.Recepcao.Domain.Entities;

namespace DPGERJ.Recepcao.Domain.Interfaces.Repository
{
    public interface IAssistidoRepository : IRepositoryBase<Assistido>
    {
        Assistido GetByDocument(string document);
    }
}