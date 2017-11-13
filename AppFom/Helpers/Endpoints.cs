using System;
namespace AppFom.Helpers
{
    public static class Endpoints
    {
        public const string loginURI = "https://i0mqxn71n1.execute-api.us-west-2.amazonaws.com/dev/login";

        public const string allEventsURI = "https://i0mqxn71n1.execute-api.us-west-2.amazonaws.com/dev/obtener_eventos";

        public const string eventsOperURI = "https://i0mqxn71n1.execute-api.us-west-2.amazonaws.com/dev/obtener_eventos_por_operador";

        public const string eventDetailURI = "https://i0mqxn71n1.execute-api.us-west-2.amazonaws.com/dev/obtener_evento_general";

        public const string updUserURI = "https://i0mqxn71n1.execute-api.us-west-2.amazonaws.com/dev/actualiza_usuario";

        public const string addCommentURI = "https://i0mqxn71n1.execute-api.us-west-2.amazonaws.com/dev/agrega_comentario";

        public const string addPhotoURI = "https://i0mqxn71n1.execute-api.us-west-2.amazonaws.com/dev/agrega_imagen";

        public const string updStatusEventURI = "https://i0mqxn71n1.execute-api.us-west-2.amazonaws.com/dev/actualiza_evento_status";

        public const string updActivityURI = "https://i0mqxn71n1.execute-api.us-west-2.amazonaws.com/dev/actualiza_actividad_evento";

    }
}
