using System;
using System.Collections.Generic;

namespace CardGames
{

    interface IPlayer
    {
        int Name { get; set; }
        List<Card> Hand { get; set; }
        bool IsActivelyPlaying { get; set; }
        bool IsTurn { get; set; }
        Guid PlayerId { get; set; }

        void Draw();
        
    }
}