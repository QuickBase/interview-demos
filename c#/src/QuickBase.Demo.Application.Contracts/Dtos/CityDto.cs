using Abp.Application.Services.Dto;
using QuickBase.Demo.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace QuickBase.Demo.Application.Contracts.Dtos
{
    public class CityDto : EntityDto<int>
    {
        [Required]
        [StringLength(ValidationConstants.MaxNameLength)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Population { get; set; }

        [Required]
        public int StateId { get; set; }
    }
}
