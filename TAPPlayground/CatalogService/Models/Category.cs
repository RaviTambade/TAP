namespace CatalogService.Models;
public class Category{
    public int CategoryId {get;set;}
    public string? CategoryTitle{get;set;}
    public string? Description{get;set;}
    public string? ImageUrl{get;set;}

//     public override string ToString(){
//     return CategoryId+"  "+CategoryTitle+"  "+Description+"  "+ImageUrl;
// }
}
