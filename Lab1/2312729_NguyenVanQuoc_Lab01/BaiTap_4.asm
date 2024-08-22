.model small
.stack 100
.data 
    dong1 db 'Hay nhap 1 ky tu: $'
    dong2 db 'Ky tu dung truoc: $'
    chuoi3 db ', da nhap: $'
    chuoi4 db ', dung sau: $'
    newline db 13,10,'$'
    kytu db ?
.code
main proc
    mov ax,@data
    mov ds,ax 
    
    mov ah,9       ;xuat dong 1
    lea dx, dong1
    int 21h
    
    mov ah,1       ;nhap 1 ky tu
    int 21h
    mov kytu, al 
    
     mov ah,9             ; xuong dong
    lea dx, newline
    int 21h
    
    lea dx, dong2      ; xuat dong 2
    int 21h
    
    dec kytu
    
    mov dl, kytu  ;xuat ky tu dung truoc
    mov ah, 2
    int 21h
    
    mov ah,9
    lea dx,chuoi3
    int 21h
    
    inc kytu
    
    mov dl, kytu
    mov ah,2
    int 21h
    
    mov ah,9
    lea dx,chuoi4
    int 21h
    
    inc kytu 
    
    mov dl, kytu
    mov ah,2
    int 21h
    
    mov ah, 04ch
    int 21h
    
    main endp
end main