﻿using Model.DTO;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IAlbumRepositorio
    {
        Task<List<Album>> GetAllAsync();

        Task<List<AlbumDTOGet>> GetDTOAllAsync();

        Task<string> GetByIDAsync(int id);

        Task<Album> CreateAsync(AlbumDTOCreate album);

        Task<int> RemoveAsync(int id);

        
    }
}
