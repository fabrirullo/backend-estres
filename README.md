## Backend de Procesamiento de Datos de Bienestar Emocional
Este es el backend para el proyecto Dashboard de Bienestar Emocional, diseñado para procesar datos de interacción del usuario (clics por segundo y movimientos del mouse) y calcular un nivel de estrés en base a dichos datos. Este backend expone una API que permite recibir estos datos, calcular el nivel de estrés y devolverlo al cliente.

## Componentes principales
WellbeingController: Controlador principal que expone el endpoint POST /api/wellbeing/process-emotion-data. Este controlador recibe datos del usuario y calcula su nivel de estrés.
UserInteractionData: Clase que representa el modelo de datos enviado por el cliente, incluyendo los campos ClicksPerSecond y MouseMovements.

## Funcionalidad
El backend procesa los datos de interacción del usuario de la siguiente manera:

Clicks por segundo (ClicksPerSecond): Si el valor es mayor a 5, por cada clic adicional se suma una penalización de estrés de 10 puntos.
Movimientos del mouse (MouseMovements): Si el valor es mayor a 1000 movimientos, se suma 1 punto de estrés por cada 100 movimientos adicionales.
El nivel de estrés calculado se devuelve al cliente y tiene un valor máximo de 100.
