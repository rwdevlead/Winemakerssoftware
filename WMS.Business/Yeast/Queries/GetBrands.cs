﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.Business.Common;
using WMS.Data.SQL;

namespace WMS.Business.Yeast.Queries
{
   /// <inheritdoc cref = "IQuery{T}" />
   public class GetBrands : IQuery<ICodeDto>
   {
      private readonly IMapper _mapper;
      private readonly WMSContext _dbContext;

      /// <summary>
      /// Brands Query Constructor
      /// </summary>
      /// <param name="dbContext">Entity Framework Context Instance as <see cref="WMSContext"/></param>
      /// <param name="mapper">AutoMapper Instance as <see cref="IMapper"/></param>       
      public GetBrands(WMSContext dbContext, IMapper mapper)
      {
         _dbContext = dbContext;
         _mapper = mapper;
      }             

      /// <summary>
      /// Asynchronously query all Brands in SQL DB
      /// </summary>
      /// <returns><see cref="Task{List{ICodeDto}}"/></returns>
      /// <inheritdoc cref="IQuery{T}.ExecuteAsync"/>
      public async Task<List<ICodeDto>> Execute()
      {
         var brands = await _dbContext.YeastBrands.ToListAsync().ConfigureAwait(false);
         var list = _mapper.Map<List<ICodeDto>>(brands);
         return list;
      }

      /// <summary>
      /// Asynchronously query a Brand in SQL DB by primary key
      /// </summary>
      /// <param name="id">Primary Key as <see cref="int"/></param>
      /// <returns><see cref="Task{ICode}"/></returns>
      /// <inheritdoc cref="IQuery{T}.ExecuteAsync(int)"/>
      public async Task<ICodeDto> Execute(int id)
      {
         var brand = await _dbContext.YeastBrands
            .FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
         var dto = _mapper.Map<ICodeDto>(brand);
         return dto;
      }

        public Task<List<ICodeDto>> Execute(int start, int length)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ICodeDto>> ExecuteByFK(int fk)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ICodeDto>> ExecuteByUser(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
