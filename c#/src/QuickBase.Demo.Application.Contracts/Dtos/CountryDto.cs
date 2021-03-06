using Abp.Application.Services.Dto;
using QuickBase.Demo.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace QuickBase.Demo.Application.Contracts.Dtos
{
    public class CountryDto: EntityDto<int>
    {
        [Required]
        [StringLength(ValidationConstants.MaxNameLength)]
        public string Name { get; set; }
    }
}
