#version 330 core
#define Imax 1000.0

in vec2 uv;

uniform vec4 region;

vec3 lerp(vec3 a, vec3 b, float t){
    return a + t*(b-a);
}

void main(){
    vec3 colors[19];
    colors[0] = vec3(106,52,3)/255.0;
    colors[1] = vec3(66,30,15)/255.0;
    colors[2] = vec3(25,7,26)/255.0;
    colors[3] = vec3(9,1,47)/255.0;
    colors[4] = vec3(4,4,73)/255.0;
    colors[5] = vec3(0,7,100)/255.0;
    colors[6] = vec3(12,44,138)/255.0;
    colors[7] = vec3(24,82,147)/255.0;
    colors[8] = vec3(57,125,209)/255.0;
    colors[9] = vec3(134,181,229)/255.0;
    colors[10] = vec3(211,236,248)/255.0;
    colors[11] = vec3(241,233,191)/255.0;
    colors[12] = vec3(248,201,95)/255.0;
    colors[13] = vec3(255,170,0)/255.0;
    colors[14] = vec3(204,128,0)/255.0;
    colors[15] = vec3(153,87,0)/255.0;
    colors[16] = vec3(106,52,3)/255.0;
    colors[17] = vec3(66,30,15)/255.0;
    colors[18] = vec3(25,7,26)/255.0;

    float R = abs(region.x-region.z)/2.0;

    vec2 coord = (uv + vec2(1.0)) * R + region.xy;
    float cx = 0.0;
    float cy = 0.0;
    float Zn = 0.0;
    float i = 0.0;
    do{
        float pomX = cx*cx - cy*cy + coord.x;
        float pomY = 2*cx*cy + coord.y;
        cx = pomX;
        cy = pomY;
        Zn = abs(cx*cx + cy*cy);
        i += 1.0;
    }while(Zn<4.0 && i <= Imax);
    
    
    float t = (Zn-4.0)/4.0;
    vec3 col = vec3(0.0);
    if(i < Imax){
        float logZn = log(Zn) / 2.0;
        float nu = log(logZn/log(2.0))/log(2);
        i = i + 1 - nu;
        t = fract(i);
    
        int index = int(t*2.0);
        float lt = t*2.0 - float(index);
        i = float(i - 17 * int(i/17));
        col = lerp(colors[int(floor(i))],colors[int(floor(i))+1],t);
        //col = colors[int(floor(i))];
    }
    else{
        col = vec3(0.0);
    }
    gl_FragColor = vec4(col,1.0);
}