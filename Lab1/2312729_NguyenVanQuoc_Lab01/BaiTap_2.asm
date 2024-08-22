.model small
.stack 100
.data    
     dong1 db 'Hay nhap mot ky tu: $'
     dong2 db 'Ky tu da nhap: $'
     newline db 13,10,'$'    
     kytu db ?

.code
    main proc 
        mov ax,@data
        mov ds,ax   
        
        ;xuat dong 1
        mov ah,9
        lea dx,dong1 
        int 21h     
        
        ;Nhap vao ky tu
        mov ah,1
        int 21h
        mov kytu,al    
        
        ;xuong dong 
        mov ah,9
        lea dx, newline 
        int 21h
        
        ;xuat dong 2
        ; mov ah,9
        lea dx, dong2
        int 21h

        ;xuat ra 1 ki tu
        mov dl,kytu
        mov ah,2
        int 21h
        
        ;thoat
        mov ah,4ch
        int 21h
    main endp
end main