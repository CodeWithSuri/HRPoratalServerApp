using HRPoratalServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPoratalServerApp.RepositoryPattren
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private RepositryPattrenContext _repoContext;
        private IEmployeeRepositry _empRepo;

        public RepositoryWrapper(RepositryPattrenContext repoContext)
        {
            _repoContext = repoContext;
        }

        public IEmployeeRepositry employeeRepositry {




            get
            {
                if (_empRepo == null)
                {

                    _empRepo = new EmployeeRepositry(_repoContext);
                }

                return _empRepo;
            }

            set => throw new NotImplementedException();

        }

        
        public void Save()
        {

            _repoContext.SaveChanges();
        }
    }
}
