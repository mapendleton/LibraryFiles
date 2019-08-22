using System;
using System.Collections.Generic;

namespace CardGames
{

    public interface IPlayer
    {
        string Name { get; set; }
        List<Card> Hand { get; set; }
        bool IsActivelyPlaying { get; set; }
        bool IsTurn { get; set; }
        Guid PlayerId { get; set; }

        void Draw();
        
    }
}