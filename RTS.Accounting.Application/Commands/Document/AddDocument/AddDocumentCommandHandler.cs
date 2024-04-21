using MediatR;
using RTS.Accounting.Application.Interfaces;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Application.Commands.Document.AddDocument
{
    public class AddDocumentCommandHandler(IUnitOfWork unitOfWork, IDocumentRepository documentRepository) : IRequestHandler<AddDocumentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDocumentRepository _documentRepository = documentRepository;
        public async Task<Unit> Handle(AddDocumentCommand request, CancellationToken cancellationToken)
        {
            _documentRepository.Add(new Domain.Entities.Document { });
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
