import { Card } from './Card';
import { SituacaoCard } from './SituacaoCard';

export interface PainelCard {
  id: number;
  situacaoId: number;
  cardId: number;
  ordemCard: number;
  posicaoVertical: number;
  posicaoHorizontal: number;
  situacaoCard: SituacaoCard;
  card: Card;
}
