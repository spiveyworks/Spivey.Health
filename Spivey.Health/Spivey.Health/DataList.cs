#region License
//MIT License

//Copyright (c) 2023 Michael Spivey

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
#endregion

namespace Spivey.Health
{
    public class DataList<T>
    {
        public DataListInfo<T> Info { get; set; }
        public DataValue<T>[] Values { get; set; }

        public DataList()
        {
            Info = new DataListInfo<T>();
            Values = new DataValue<T>[0];
        }

        public DataList(DataValue<T>[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            Values = values;
            Info = new DataListInfo<T>()
            {
                Id = Guid.NewGuid().ToString(),
                StartDate = values?.Min(d => d.Date) ?? null,
                EndDate = values?.Max(d => d.Date) ?? null,
            };
        }

        public DataList(DataListInfo<T> info, DataValue<T>[] values)
        {
            Info = info;
            Values = values;
        }
    }
}
