module tests

    open NUnit.Framework
    open FsUnit
    open PhoneBook
    
    [<Test>]
    let ``Find with existing phone`` () =
        let book = [{Name="Voland"; Phone=666};{Name="Koroviev"; Phone=000};{Name="Cat"; Phone=123}]
        let phone = 666
         
        (book, phone) ||> FindName |> should equal (Some "Voland")
        
    [<Test>]
    let ``Find with missing phone`` () =
        let book = [{Name="Voland"; Phone=666};{Name="Koroviev"; Phone=000};{Name="Cat"; Phone=123}]
        let phone = 111
         
        (book, phone) ||> FindName |> should equal None
        
    [<Test>]
    let ``Find with existing name`` () =
        let book = [{Name="Voland"; Phone=666};{Name="Koroviev"; Phone=000};{Name="Cat"; Phone=123}]
        let name = "Voland"
         
        (book, name) ||> FindPhone |> should equal (Some 666)
        
    [<Test>]
    let ``Find with missing name`` () =
        let book = [{Name="Voland"; Phone=666};{Name="Koroviev"; Phone=000};{Name="Cat"; Phone=123}]
        let name = "Berlioz"
         
        (book, name) ||> FindPhone |> should equal None
        
    [<Test>]
    let ``Test adding record`` () =
        let book = []
        let record = {Name="Voland"; Phone=666}
        
        (book, record) ||> AddRecord |> should equal [{Name="Voland"; Phone=666}]
    
    open System.IO
    
    [<Test>]
    let ``Test saving and reading with files`` () =
        let book1 = [{Name="Voland"; Phone=666};{Name="Koroviev"; Phone=000};{Name="Cat"; Phone=123}]
        let path = Path.Combine("./", "test.txt")
        
        (path, book1) ||> SaveBook
        let book2 = path |> ReadBook
        
        book1 |> should equal book2
        
    