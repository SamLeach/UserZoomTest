<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <p>
  <b>Ejercicio 1: </b>Crea una nueva opción en el menú llamada "Surveys" que contenga:
</p>
<p>
  1-. Listado en forma de tabla de los surveys (MNG_SURVEY) que todavia necesitan mas datos (es decir, donde completes < needed) para los estudios creados en los 2 últimos meses y que tienen una descripcion
</p>
  La tabla debe contener los siguientes datos:
<p>
  Study title, Survey title, completes, needed, participants needed (needed-completes)
</p>
<p>
  2-. "El total de completes en surveys de estudios es: " y dicho valor que es la suma de los "completes" en la tabla de MNG_SURVEY de la consulta previa. Sólo hay que mostrar este mensaje si dicho valor es superior a 10.
</p>
<p>
  <lu>
    Otras consideraciones:
    <li>
      La página que crearás será similar a la de Tasks.aspx, puedes basarte en ella como ejemplo, donde ya verás como se utilizan las funciones de base de datos y de transformación del xslt.
    </li>
    <li>
      Ten en cuenta que la cantidad de registros en las tablas podría ser mucho mayor a la hora de crear una solución que sea eficiente, la única limitación es no modificar las 3 tablas existentes.
    </li>
  </lu>
</p>
<p>
  <b>Ejercicio 2: </b>Modifica la funcion checkShowWarning() en Tasks.aspx para que se elimine la classe "uz-hidden" del warning "warn-limit" en el caso de que en el json myJSONTasksConfig el total de completes (total) sea mayor al limite de tareas de la cuenta (limit)
</p>
</asp:Content>
