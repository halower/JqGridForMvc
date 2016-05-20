# JqGridForMvc
JqGridForMvc is most simple and popular JqGrid plugin that can be used to quickly create a commercial request form. We are also pursuing: "write less, do more", if you have any questions or help with it you can send email to me or contact me
#Demo
Here is a simple example, but JqgridForMvc has supported the most common Jqgrid operation, there is time to do supplementary examples
```
<script id="testTmp" type="text/html">                                 
    <button class="btn btn-sm btn-danger" onclick="alert('{{name}}')">{{name}}</button>                                 
</script>                                   
<script>                                                             
    function inlineHtmlTest(cellvalue, options, rowObject) {                                    
        return halower.template('testTmp', { name: rowObject[1] });                                    
    }                                                             
</script>   

@model GBBMS.Service.User.UserDto
@{
    var g = Html.JqGridKit();
}
<div class="row GBBMSGrid" style="margin-top: 10px">                              
    @(                                  
    g.JqGrid("userlistGrid", g.Param(p => p.Id)).MainGrid(                                
        g.GridColumn(x => x.Id, 300),                                   
        g.GridColumn(x => x.UserName, 300).Searchable(),                                    
        g.GridColumn(x => x.PhoneNumber, 300).Searchable(),                                    
        g.GridColumn("操作",150, "inlineHtmlTest")                                    
        )                                  
        .Caption("用户列表").Height("150")                        
        .Url(Url.Action("UserListData", "Account")).Multiselect()                        
        .Pager().PerClearCache().MultiSearch().AutoWidth()                          
        .BuiltInOperation(GridOperators.Refresh | GridOperators.Search | GridOperators.Add)                                  
    )                               
</div>
```
>BACK-END CODE(Only a word)
```
public ContentResult UserListData()
{
     return Content(UserAppService.UserList().Pagination(this));
}
```

