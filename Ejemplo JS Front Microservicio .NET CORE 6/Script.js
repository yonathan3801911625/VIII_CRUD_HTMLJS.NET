//read
function  consultar()
{
    // var cedula = 111;

    var request = new Request('https://localhost:7060/api/Values/', {
        method: 'get',
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        alert(data);
    })
    .catch(function(err) {
        console.error(err);
    });
}

//create
function guardar()
{
    
var cedula=document.getElementById("id").value;
var nombre=document.getElementById("name").value;
var edad=document.getElementById("age").value;
// var id = Integer.parseInt(jsonObj.get("id"));

// var cedula="1053";
// var nombre="yon";
// var edad=23;

var request = new Request('https://localhost:7060/api/Values', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              ced: cedula,
              nom: nombre,
              ed: parseInt(edad)
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
 
      
    })
    .catch(function(err) {
        console.error(err);
    });
}


//delete
function eliminar()
{
    var cedula=document.getElementById("idDelete").value;
    // var cedula="1053";

var request = new Request('https://localhost:7060/api/Values/', {
        method: 'delete',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              ced: cedula
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
 
      
    })
    .catch(function(err) {
        console.error(err);
    });
}


//update
function actualizar()
{

var cedula = document.getElementById("idUpdate").value;
var nombre=document.getElementById("nameUpdate").value;
var edad=document.getElementById("ageUpdate").value;

// var id="1";
// var cedula="1053";
// var titulo="la hoja";
// var descripcion="la hoja cayo del arbol";

var request = new Request('https://localhost:7060/api/Values/', {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
          },
            body: JSON.stringify({
              ced: cedula,
              nom: nombre,
              eda: edad
          })
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
   
    .then(function(data) {
        alert(data);
 
      
    })
    .catch(function(err) {
        console.error(err);
    });
}