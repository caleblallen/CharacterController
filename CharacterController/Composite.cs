using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharacterController
{

    public class ScreenStyle
    {
        public string TopLeftCorner { get; set; } = "╔";
        public string TopRightCorner { get; set; } = "╗";
        public string BottomRightCorner { get; set; } = "╝";
        public string BottomLeftCorner { get; set; } = "╚";
        public string HorizontalLine { get; set; } = "═";
        public string VerticalLine { get; set; } = "║";
    }

    public class Glyph
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private List<Glyph> children = new List<Glyph>();
        protected StringBuilder contentBuilder = new StringBuilder();

        public virtual string Render()
        {
            return "";
        }
    }

    public class BorderedGlyph : Glyph
    {
        public ScreenStyle Style { get; set; }

    }

    public class Composite : BorderedGlyph
    {
        public Composite()
        {
            base.Width = Constants.MAX_ROWS - 1;
        }
        public virtual string Render()
        {

            drawBorderAround(prepareContent());

            return contentBuilder.ToString();
        }
        //─ │ ┌ ┐ └ ┘ ├ ┤ ┬ ┴ ┼ ═ ║ ╒ ╓ ╕ ╔ ╖ ╗ ╘ ╙ ╚ ╛ ╜ ╞ ╝ ╟ ╠ ╡ ╢ ╣ ╤ ╥ ╦ ╧ ╨ ╩ ╪ ╫ ╬ 

        private void AddTopBorder()
        {
            contentBuilder.Append(Style.TopLeftCorner);
            contentBuilder.Append(String.Concat(Enumerable.Repeat(Style.HorizontalLine, Width - 2)));
            contentBuilder.AppendLine(Style.TopRightCorner);
        }

        private void AddBottomBorder()
        {
            contentBuilder.Append(Style.BottomLeftCorner);
            contentBuilder.Append(String.Concat(Enumerable.Repeat(Style.HorizontalLine, Width - 2)));
            contentBuilder.AppendLine(Style.BottomRightCorner);
        }

        private void AddSideBorders(string content)
        {

            foreach(string line in content.Split('\n'))
            {
                contentBuilder.Append(Style.VerticalLine);
                contentBuilder.Append(line);
                contentBuilder.AppendLine(Style.VerticalLine);
            }
        }

        private string prepareContent()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Height - 3; i++)
            {
                foreach (var space in Enumerable.Repeat(" ", Width - 2))
                    sb.Append(space);
            }

            return sb.ToString();
        }

        private void drawBorderAround(string content)
        {
            AddTopBorder();
            AddSideBorders(content);
            AddBottomBorder();
        }
    }
}
