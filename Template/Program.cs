
//using CRUD.Actions.Implementation;
//using Template;

//var context = new AppDBContext();

//context.Users.Add(new()
//{
//    Name = "s"
//});
//context.Users.Add(new()
//{
//    Name = "Djo"
//});

//context.SaveChanges();

//var users = context.Users.ToList();

//foreach (var user in users)
//{
//    Console.WriteLine(user.Id);
//    Console.WriteLine(user.Name);
//    Console.WriteLine(user.GetPrimaryKey());
//}

//var bc = new BaseCRUDRepository<User, int>(context);

//var newUser = await bc.Read(u => u.Name != null);


//Console.WriteLine();

//using Common.Models;

//var car = new Car();

//var props = typeof(Car).GetProperties();


//foreach (var prop in props)
//{
//    Console.WriteLine(prop);
//}