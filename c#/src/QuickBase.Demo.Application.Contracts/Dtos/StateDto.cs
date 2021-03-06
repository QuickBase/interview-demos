using Abp.Application.Services.Dto;
using QuickBase.Demo.Domain.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickBase.Demo.Application.Contracts.Dtos
{
    public class StateDto : EntityDto<int>
    {
        [Required]
        [StringLength(ValidationConstants.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
