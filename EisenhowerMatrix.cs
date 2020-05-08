using System.Collections.Generic;
using MatrixCreator.Templates;

namespace MatrixCreator
{
    public class EisenhowerMatrix
    {
        internal readonly Dictionary<MatrixType, List<MatrixItem>> Data;
        internal readonly IMatrixTemplate MatrixTemplate;

        public EisenhowerMatrix()
        {
            MatrixTemplate = new SimpleTemplate();
            Data = 
                new Dictionary<MatrixType, List<MatrixItem>>
                {
                    [MatrixType.Urgent_Important] = new List<MatrixItem>(),
                    [MatrixType.NotUrget_Important] = new List<MatrixItem>(),
                    [MatrixType.Urgent_NotImportant] = new List<MatrixItem>(),
                    [MatrixType.NotUrget_NotImportant] = new List<MatrixItem>(),
                };
        }
        
        public EisenhowerMatrix(IMatrixTemplate template)
        {
            MatrixTemplate = template;
            Data = 
                new Dictionary<MatrixType, List<MatrixItem>>
                {
                    [MatrixType.Urgent_Important] = new List<MatrixItem>(),
                    [MatrixType.NotUrget_Important] = new List<MatrixItem>(),
                    [MatrixType.Urgent_NotImportant] = new List<MatrixItem>(),
                    [MatrixType.NotUrget_NotImportant] = new List<MatrixItem>(),
                };
        }
        
        public void AddItem(MatrixItem item, MatrixType type)
        {
            Data[type].Add(item);
        }
    }
}