namespace iHakeem.Application.Common.Constants
{
    /// <summary>
    ///     Represents all available routes.
    /// </summary>
    public static class Routes
    {
        /// <summary>
        ///     Represents API route prefix.
        /// </summary>
        public const string Api = "/api";

        /// <summary>
        /// Documents route prefix.
        /// </summary>
        public const string Docs = "/docs";

        /// <summary>
        ///     Swagger route.
        /// </summary>
        public const string Swagger = "/swagger";

        /// <summary>
        ///     Swagger UI start page route.
        /// </summary>
        public static readonly string SwaggerUiStartPageRoute = $"{Swagger}/index.html";


    }
}
