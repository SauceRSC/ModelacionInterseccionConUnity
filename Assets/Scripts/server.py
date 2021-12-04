from http.server import HTTPServer, BaseHTTPRequestHandler

class MyHandler(BaseHTTPRequestHandler):
    def do_GET(self):

        response = """{
    \"data\": [
        {\"x\":-11.8, \"y\":0.25, \"z\":-0.5, \"r\":-90.0},
        {\"x\":0.5, \"y\":0.25, \"z\":11.8, \"r\":0}
    ]
}"""
        # send 200 response
        self.send_response(200)
        # send response headers
        self.end_headers()
        # send the body of the response
        self.wfile.write(bytes(response, "utf-8"))

httpd = HTTPServer(('localhost', 8000), MyHandler)
httpd.serve_forever()