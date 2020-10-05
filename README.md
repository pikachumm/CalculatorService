# CalculatorService 
Aplicacion cliente servidor escrita en c# usando visual studio 2015 consistente en dos partes el cliente una aplicacion de consola y el servidor una aplicacion de tipo web api
## Comenzando 🚀
Para comenzar descargarse el proyecto y ejecutarlo con visual studio 2015
## Librerias externas 📋
* [Nlog](https://nlog-project.org/) y [Nlog.Config](https://nlog-project.org/) - Para crear fichero de log
* [RestSharp](https://restsharp.dev/) - Libreria para REST API
* [Newtonsoft.Json](https://www.newtonsoft.com/json) - popular libreria de JSON
## CalculatorClient ⚙️
cliente de consola a excepcion de query en cada una de las opciones se le preguntara al usuario si desea guardar las operaciones y el id correspondiente con las siguientes opciones:
#### Add
suma de n numeros introducidos los manda en AddRequest y los recibe en AddResponse
#### Substract
resta de dos numeros introducidos los manda en SubstractRequest y los recibe en SubstractResponse
#### Multiply
multiplica n numeros introducidos por el usuario los manda en MultiplyRequest y los recibe en MultiplyResponse
#### Div
Divide 2 numeros introducidos por el usuario los manda en DivRequest y los recibe en DivResponse
#### Square
Saca la raiz cuadrada del numero introducido los manda en SquareRequest y los recibe en SquareResponse
#### Query
Dado un Id muestra todas las operaciones guardadas asociadas los manda en QueryRequest y los recibe en QueryResponse
#### Exit
Salir del sistema
## CalculatorServer ⚙️
Aplicacion de tipo webApi encargada de recibir las peticion de tipo POST para las calculadoras en cada uno de los metodos a excepcion de query comprobara el header X-Evi-Tracking-Id y si se mando se encargara de almacenar las operaciones
#### AddPost
recibe un AddRequest con todos los numeros a sumar y devuelve un AddResponse con el resultado
#### SubstractPost
recibe un SubstractRequest con los numeros a restar y devuelve un SubstractResponse con el resultado
#### MultiplyPost
recibe un MultiplyRequest  con los numeros a multiplicar y devuelve un MultiplyResponse con el producto
#### DivPost
recibe un DivRequest con las operacion y devuelve un DivResponse con el resultado
#### SquarePost
recibe un SquareRequest con el numero a realizar la raiz cuadrada y devuelve un SquareResponse con el resultado
#### QueryPost
recibe un QueryRequest con un id con el registro a buscar y devuelve un QueryResponse con las operaciones
