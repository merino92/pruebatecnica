$(document).ready(function(){
    List();
    $("#btnsave").click(e =>{
        console.log(nuevo);
        if(parseInt(nuevo) > 0){
            console.log('create');
            create();
        }else{
            console.log('update');
            update();
        }
       
    });
    $("#btnew").click(e=>{
        showModal();
    });
});
var nuevo=0;
var idupdate =0;
function showModal(){
    $('#exampleModal').modal('show');
    $("#catalogo").val(null);
    
    nuevo++;
}

function List(){
    $("#tbl").html(null); //limpia la tabla
    var html = '';
    $.ajax({
        type:'GET',
        url: '/Categoria/List',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    success: function (data) {
        console.log(data);
            if (data.length > 0) {
                $.each(data, function (index, value) {
                    html += '<tr>';
                    html += '<td>' + value.id + '</td>';
                    html += '<td>' + value.nombre + '</td>';
                    html += '<td><button type="button" onClick="showData('+value.id+')" class="btn btn-warning ml-2">Editar</button>';
                    html += '<button type="button" class="btn btn-danger ml-2" onClick="eraser('+value.id+','+
                            "'"+value.nombre+"'"+')" >Eliminar</button></td>';
                    html += '</tr>';
                }); //recorremos los datos y los formateamos
            }//verificamos que tenga datos la respuests
        $("#tbl").html(html); //agregamos lo datos a la tabla

        }, error: function (xhr, status, error) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error

        });
        }
    }); 
} // lista las categorias

function create(){
    var datos= {
        Id:0,
        nombre:$("#catalogo").val()
    };
    console.log(datos);
    $.ajax({
        type:'POST',
        url:'/Categoria/add',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data:JSON.stringify(datos),
    success: function (data) {
                   if(data.error > 0){
                    Swal.fire({
                        icon: 'error',
                        title: 'Error!',
                        text: data.response
            
                    });
                    
                   }else{
                    $('#exampleModal').modal('hide');
                    $("#catalogo").val(null);
                    Swal.fire({
                        icon: 'success',
                        title: 'Exito!!',
                        text: data.response
            
                    });
                    List();
                    }
           
        

        }, error: function (xhr, status, error) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error

        });
        }
    }); 
} //crea la categoria

function eraser(id, nombre){
    Swal.fire({
        title: 'Estas Seguro?',
        text: "Eliminaras la categoria "+nombre,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'eliminar',
        cancelButtonText:'cancelar'
      }).then((result) => {
        if (result.value) {
          remove(id,Swal);
        }
      })
}

function remove(id,alert){
    var datos= {
        Id:id,
        nombre:null
    };
    console.log(datos);
    $.ajax({
        type:'DELETE',
        url:'/Categoria/delete',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data:JSON.stringify(datos),
    success: function (data) {
                   if(data.error > 0){
                       alert.close();
                    Swal.fire({
                        icon: 'error',
                        title: 'Error!',
                        text: data.response
            
                    });
                    
                   }else{
                    alert.close();
                    Swal.fire({
                        icon: 'success',
                        title: 'Exito!!',
                        text: data.response
            
                    });
                    List();
                    }
           
        

        }, error: function (xhr, status, error) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error

        });
        }
    }); 
} 
function modalOff(){
    $('#exampleModal').modal('hide');
    $("#catalogo").val(null);
    idupdate =0;
    nuevo =0;
    
}
function showData(id){
    console.log(id);
    nuevo =0;
    $.ajax({
        type:'GET',
        url: '/Categoria/ListId?id='+id,
        contentType: "application/json; charset=utf-8",
       
        dataType: "json",
    success: function (data) {
            if(data.error>0){
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text:  data.response
        
                });
            }else{
                
                
                $('#exampleModal').modal('show');
                $("#catalogo").val(data.nombre);
                idupdate =id;
                
            }

        }, error: function (xhr, status, error) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error

        });
        }
    }); 
}

function update(){
    var datos= {
        Id:idupdate,
        nombre:$("#catalogo").val()
    };
    console.log(datos);
    $.ajax({
        type:'PUT',
        url:'/Categoria/update',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data:JSON.stringify(datos),
    success: function (data) {
                   if(data.error > 0){
                    Swal.fire({
                        icon: 'error',
                        title: 'Error!',
                        text: data.response
            
                    });
                    
                   }else{
                    $('#exampleModal').modal('hide');
                    $("#catalogo").val(null);
                    idupdate =0;
                    nuevo =0;
                    Swal.fire({
                        icon: 'success',
                        title: 'Exito!!',
                        text: data.response
            
                    });
                    List();
                    }
           
        

        }, error: function (xhr, status, error) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: error

        });
        }
    }); 
}

