.model small
.stack 100
.data
    dong1 db 'Nhap ky tu thu nhat: $'
    dong2 db 'Nhap ky tu thu hai: $'  
    dong3 db 'Ky tu tong: $'
    newline db 13,10,'$'
    
.code 
main proc
    mov ax,@data
    mov ds, ax
    
    mov ah,9         ;xuat dong 1  
    lea dx, dong1
    int 21h
    
    mov ah,1    ; nhap 1 ki tu va gan vao bl
    int 21h 
    mov bl, al
    
    mov ah,9           ;xuong dong
    lea dx, newline
    int 21h
    
    
    mov ah,9         ;xuat dong 2  
    lea dx, dong2
    int 21h 
    
    mov ah,1             ;nhap 1 ki tu va gan vao cl
    int 21h 
    mov cl, al
    
    add bl,cl                 ;tong cua 2 ky tu
    
    mov ah,9                 ;xuong dong
    lea dx, newline
    int 21h
     
    lea dx, dong3          ;xuat dong 3
    int 21h  
    
    mov dl,bl
    mov ah,2 
    int 21h
    
    mov ah, 4ch 
    int 21h
    
    main endp
end main

