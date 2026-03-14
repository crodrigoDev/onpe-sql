# Se añadio la cadena de conexion a mi base de datos en Azure
Las cadenas de conexion estan en el archivo appsettings.json, ir a clsBD dentro de Controllers/bd y cambiar el _cadenaConexion a la de azure,
hubo un problema al cargar o recuperar con el archivo bak la base de datos y es que el usp getDepartamentos no tenia parametros, en el local cambiar si sale dicho
error, en la base de datos en Azure esta todo correcto.
