using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITodoService
    {
        IDataResult<List<Todo>> GetAll();
        IDataResult<Todo> GetById(int todoId);
        IResult Add(Todo todo);
        IResult Update(Todo todo);
        IResult Delete(Todo todoId);
    }
}
