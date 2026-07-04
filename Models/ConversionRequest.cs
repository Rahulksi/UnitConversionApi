using System.ComponentModel.DataAnnotations;

namespace UnitConversionApi.Models
{
    public record ConversionRequest(
        [Required] double Value,
        [Required] string FromUnit,
        [Required] string ToUnit
        );

}
