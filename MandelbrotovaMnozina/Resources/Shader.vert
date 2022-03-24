#version 330 core

layout(location=0) in vec2 Position;
out vec2 uv;

void main(){
    uv = Position;
    gl_Position = vec4(Position,0.0,1.0);
}