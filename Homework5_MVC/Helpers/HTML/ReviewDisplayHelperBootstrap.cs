using System.Text;
using System.Text.Encodings.Web;
using Homework5_MVC.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework5_MVC.Helpers.HTML
{
    public static class ReviewDisplayHelperBootstrap
    {
        public static HtmlString CreateReview(this IHtmlHelper helper, Review review)
        {
            TagBuilder divCard = new TagBuilder("div");
            divCard.Attributes.Add("class", "card mb-3");

            TagBuilder divCardInner = new TagBuilder("div");
            divCardInner.Attributes.Add("class", "card-body");

            TagBuilder h5Username = new TagBuilder("h5");
            h5Username.Attributes.Add("class", "card-text");
            h5Username.InnerHtml.Append($"From: {review.UserName}");

            TagBuilder divStars = new TagBuilder("div");

            for (int i = 0; i < review.Rating; i++)
            {
                TagBuilder star = new TagBuilder("i");
                star.Attributes.Add("class", "bi bi-star-fill fs-5");
                divStars.InnerHtml.AppendHtml(star);
            }

            for (int i = review.Rating; i < 5; i++)
            {
                TagBuilder star = new TagBuilder("i");
                star.Attributes.Add("class", "bi bi-star fs-5");
                divStars.InnerHtml.AppendHtml(star);
            }

            TagBuilder pText = new TagBuilder("p");
            pText.Attributes.Add("class", "card-text");
            pText.InnerHtml.Append(review.Text);

            divCard.InnerHtml.AppendHtml(divCardInner);

            divCardInner.InnerHtml.AppendHtml(h5Username);
            divCardInner.InnerHtml.AppendHtml(divStars);
            divCardInner.InnerHtml.AppendHtml(pText);

            using StringWriter writer = new StringWriter();
            divCard.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}

