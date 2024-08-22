.model small
.stack 100
.data 
     dong1 db 'Hello, world ! $'
     dong2 db 'Hello, solar system ! $' 
     dong3 db 'Hello, universe ! $' 
     newline db 13,10,'$'

.code
main proc 
        
    mov ax,@data
    mov ds,ax 
        
    ;xuat dong 1
    mov ah,9  
    lea dx, dong1
    int 21h    
    
    ;xuong dong
    lea dx, newline
    int 21h
    
    ;xuat dong 2
    lea dx, dong2
    int 21h
    
    ;xuong dong
    lea dx, newline
    int 21h    
    
    ;xuat dong 3
    lea dx, dong3
    int 21h  
        
        
    mov ah,4ch   ;thoat
    int 21h    
             
    main endp
end main