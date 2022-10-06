using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Models;
using AspNetCoreAssessment.Reposatory;
using AutoMapper;

namespace AspNetCoreAssessment.Manger
{
    public class DocumentFilesManger
    {
        private readonly BaseRepo<DocumentFiles> documentFilesRepo;
        private readonly IMapper mapper;

        public DocumentFilesManger(AspnetcoreassessmentContext DbCotext,IMapper mapper )
        {
            documentFilesRepo = new BaseRepo<DocumentFiles>(DbCotext);
            this.mapper = mapper;
        }
        public void UploadFile(DocumentFilesVM documentFilesVM)
        {
            documentFilesVM.FilePath = FileManger.UploadFile(documentFilesVM.DocumentFile,
                "/wwwroot/Uploads/" + documentFilesVM.DocumentFolderName + "/");
            DocumentFiles data =mapper.Map<DocumentFiles>(documentFilesVM);
            documentFilesRepo.Add(data);


        }
    }
}
