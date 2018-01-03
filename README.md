# JqGridForMvc
JqGridForMvc is most simple and popular JqGrid plugin that can be used to quickly create a commercial request form. We are also pursuing: "write less, do more", if you have any questions or help with it you can send email to me or contact me
#Installation
``` Install-Package HalowerHub.Jqgrid```
#Sample Code
![](http://images.cnitblog.com/blog/360406/201502/081159015477052.gif)
Here is a simple example, but JqgridForMvc has supported the most common Jqgrid operation, there is time to do supplementary examples
```
@model GBBMS.Service.User.UserDto
@{
    var g = Html.JqGridKit();
}
<div class="row" style="margin-top: 10px">                              
    @(                                  
    g.JqGrid("userlistGrid", g.Param(p => p.Id)).MainGrid(                                
        g.GridColumn(x => x.Id, 300),                                   
        g.GridColumn(x => x.UserName, 300).Searchable(),                                    
        g.GridColumn(x => x.PhoneNumber, 300).Searchable(),                                    
        g.GridColumn("options",150, "custom html fragment")                                 
        )                                  
        .Caption("user grid").Height("150")                        
        .Url(Url.Action("UserListData", "Account")).Multiselect()                        
        .Pager().PerClearCache().MultiSearch().AutoWidth()                          
        .BuiltInOperation(GridOperators.Refresh | GridOperators.Search | GridOperators.Add)                                  
    )                               
</div>
```
or:SubGrid
![](http://images.cnitblog.com/blog2015/360406/201503/160929184381770.png)
#back-end -code(Only a word)
```
public ContentResult UserListData()
{
    return Content(dataSource.Pagination(this));
}
```

