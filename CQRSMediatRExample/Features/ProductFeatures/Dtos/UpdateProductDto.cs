using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Dtos;

public record UpdateProductDto(string Name)
{
    public Product ToProduct()
        => new() { Name = Name };
}
