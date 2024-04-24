using MediatR;
using RTS.Accounting.Application.Dtos;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Application.Queries
{
    public record GetDocumentQuery(int Id) : IRequest<DocumentDto>;

    public class GetDocumentQueryHandler(IDocumentRepository documentRepository) : IRequestHandler<GetDocumentQuery, DocumentDto>
    {
        private readonly IDocumentRepository _documentRepository = documentRepository;
        public async Task<DocumentDto> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            var document = await _documentRepository.GetAsync(request.Id, cancellationToken);

            return DocumentDto.Map(document);
        }

    }
}
