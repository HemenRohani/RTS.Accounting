using MediatR;
using RTS.Accounting.Domain.Interfaces;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Application.Commands
{
    public record RemoveDocumentCommand(int id) : IRequest<Unit>;

    public class DeleteDocumentCommandHandler(IUnitOfWork unitOfWork, IDocumentRepository documentRepository) : IRequestHandler<RemoveDocumentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDocumentRepository _documentRepository = documentRepository;
        public async Task<Unit> Handle(RemoveDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _documentRepository.GetAsync(request.id, cancellationToken);
            _documentRepository.Remove(document);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
