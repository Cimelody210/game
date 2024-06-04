#include <SDL2/SDL.h>
#include <iostream>

const int SCREEN_WIDTH = 640;
const int SCREEN_HEIGHT = 480;

class Game {
public:
    Game();
    bool init();
    void loop();
    void close();

private:
    SDL_Window* window;
    SDL_Renderer* renderer;
    bool isRunning;
    int x, y; // coordinates of the ball
};

Game::Game() : window(nullptr), renderer(nullptr), isRunning(true), x(SCREEN_WIDTH/2), y(SCREEN_HEIGHT/2) {}

bool Game::init() {
    if (SDL_Init(SDL_INIT_VIDEO) != 0) {
        std::cerr << "SDL_Init Error: " << SDL_GetError() << std::endl;
        return false;
    }

    window = SDL_CreateWindow("Shooting Game", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN);
    if (window == nullptr) {
        std::cerr << "SDL_CreateWindow Error: " << SDL_GetError() << std::endl;
        SDL_Quit();
        return false;
    }

    renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED | SDL_RENDERER_PRESENTVSYNC);
    if (renderer == nullptr) {
        SDL_DestroyWindow(window);
        std::cerr << "SDL_CreateRenderer Error: " << SDL_GetError() << std::endl;
        SDL_Quit();
        return false;
    }

    return true;
}

void Game::loop() {
    SDL_Event event;
    while (isRunning) {
        while (SDL_PollEvent(&event)) {
            if (event.type == SDL_QUIT) {
                isRunning = false;
            }
            if (event.type == SDL_KEYDOWN) {
                switch(event.key.keysym.sym) {
                    case SDLK_UP:
                        y -= 10;
                        break;
                    case SDLK_DOWN:
                        y += 10;
                        break;
                    case SDLK_LEFT:
                        x -= 10;
                        break;
                    case SDLK_RIGHT:
                        x += 10;
                        break;
                }
            }
        }

        SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);
        SDL_RenderClear(renderer);

        SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);
        SDL_Rect ball = {x, y, 20, 20};
        SDL_RenderFillRect(renderer, &ball);

        SDL_RenderPresent(renderer);
    }
}

void Game::close() {
    SDL_DestroyRenderer(renderer);
    SDL_DestroyWindow(window);
    SDL_Quit();
}

int main() {
    Game game;
    if (!game.init()) {
        std::cerr << "Initialization failed!\n";
        return 1;
    }

    game.loop();
    game.close();

    return 0;
}
