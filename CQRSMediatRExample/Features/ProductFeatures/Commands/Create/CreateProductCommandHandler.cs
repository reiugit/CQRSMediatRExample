using MediatR;
using CQRSMediatRExample.Data;
using CQRSMediatRExample.Features.ProductFeatures.Dtos;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Create;

public class CreateProductCommandHandler(AppDbContext context) : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.CreateProductDto.ToProduct();

        context.Add(product);
        await context.SaveChangesAsync(cancellationToken);

        return ProductDto.FromProduct(product);
    }
}
