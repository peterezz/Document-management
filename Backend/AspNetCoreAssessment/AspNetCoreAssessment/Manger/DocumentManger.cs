using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Models;
using AspNetCoreAssessment.Reposatory;
using AutoMapper;

namespace AspNetCoreAssessment.Manger
{
    public class DocumentManger
    {
        private readonly BaseRepo<Documents> DocumentRepo;
        private readonly IMapper mapper;
        private readonly DocumentFilesManger documentFilesManger;

        public DocumentManger(AspnetcoreassessmentContext DbContext, IMapper mapper)
        {
            DocumentRepo = new BaseRepo<Documents>(DbContext);
            this.mapper = mapper;
            documentFilesManger = new DocumentFilesManger(DbContext,mapper);
        }
        public void UploadDocument(DocumentVM documentVM)
        {
            Documents document = map(documentVM);
            DocumentRepo.Add(document);

            int documentId = DocumentRepo.GetLastOne(document => document.Name.Equals(documentVM.Name)).DocumentId;
            string FolderName = FolderManger.CreateNewFolder(documentVM.Name, documentId);

            foreach (var file in documentVM.DocumentFiles)
            {
                DocumentFilesVM DocumentFile = new DocumentFilesVM { DocumentFile = file, DocumentId = documentId, DocumentFolderName=FolderName };
                documentFilesManger.UploadFile(DocumentFile);
            }
        }
        public IQueryable<Documents> SearchDocument(string SearchVal = null)
        {
            if (string.IsNullOrEmpty(SearchVal)){
              return DocumentRepo.GetAll();

            }
            return DocumentRepo.GetMany(doc => doc.Name.Contains(SearchVal) || 
            doc.Created.ToString().Contains(SearchVal) || 
            doc.DueDate.ToString().Contains(SearchVal) || 
            doc.Priority.ToString().Contains(SearchVal) || 
            doc.Created.ToString().Contains(SearchVal) || 
            doc.Date.ToString().Contains(SearchVal));
        }
        public DocumentVM GetDocumentById(int id)
        {
            var data = DocumentRepo.GetOne(doc => doc.DocumentId == id, doc => doc.PriorityNavigation);
            if (data == null)
                return null;
            DocumentVM documentVM =mapper.Map<DocumentVM>(data);
            documentVM.PriorityName = data.PriorityNavigation.Name;
            return documentVM;

        }
        public void UpdateDocument(DocumentVM documentVM)
        {
            Documents doc= map(documentVM);
            DocumentRepo.Edit(doc);
        }
        public void DeleDocument(int Id)
        {
            var data = GetDocumentById(Id);
            string DocumentName = data.Name + "_" + data.DocumentId;
            FolderManger.DeleteFolder(DocumentName);
            DocumentRepo.Delete(Id);
        }
        public List<DocumentVM> GetDocuments()
        {
           var data = DocumentRepo.GetAll();
            return mapper.Map<IQueryable<DocumentVM>>(data).ToList();

            }
            private Documents map(DocumentVM documentVM)
        {
            Documents doc = new Documents {DocumentId=documentVM.DocumentId, Name = documentVM.Name, Date = documentVM.Date, DueDate = documentVM.DueDate, Priority = documentVM.Priority,Created=documentVM.Created };
            return doc;
        }
      
    }
}
